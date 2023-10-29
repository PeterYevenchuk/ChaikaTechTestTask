using ChaikaTechTestTask.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTechTestTask.Core.Points;

public class DailyPointsCalculator
{
    #region const
    private const int POINTS_FIRST_DAY_MONTH = 2;
    private const int POINTS_SECOND_DAY_MONTH = 3;

    private const int SPRING = 3;
    private const int SUMMER = 6;
    private const int AUTUMN = 9;
    private const int WINTER = 12;

    private const int FIRS_DAY = 1;
    private const int SECOND_DAY = 2;

    private const double PERCENTAGE_DIVISION_YESTERDAY = 0.6;
    #endregion

    private readonly ChaikaTechDbContext _context;

    public DailyPointsCalculator(ChaikaTechDbContext context)
    {
        _context = context;
    }

    public async Task<double> CalculateDailyPointsForUser(int userId)
    {
        if (userId <= 0)
        {
            throw new ArgumentException("User id must be greater than 0!");
        }

        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

        if (user == null)
        {
            throw new ArgumentException("User not found!!");
        }

        DateTime currentDateAndTime = DateTime.Now;
        DateOnly currentDate = DateOnly.FromDateTime(currentDateAndTime);

        var points = await DetermineSeason(currentDate, userId);

        return points;
    }

    private async Task<double> DetermineSeason(DateOnly currentDate, int userId)
    {
        var points = await _context.Points.FirstOrDefaultAsync(u => u.UserId == userId);
        if (points == null)
        {
            throw new ArgumentException("User points not found!!");
        }

        int month = currentDate.Month;
        int day = currentDate.Day;

        if (IsFirstDayOfSeason(month, day))
        {
            UpdatePointsForNewDay(points, currentDate, POINTS_FIRST_DAY_MONTH, points.YesterdayPoints, points.TodayPoints);
        }
        else if (IsSecondDayOfSeason(month, day))
        {
            UpdatePointsForNewDay(points, currentDate, POINTS_SECOND_DAY_MONTH, points.YesterdayPoints, points.TodayPoints);
        }
        else
        {
            /* today's points are yesterday's because they are
            recorded as today for each day in the database,
            so if the user enters the program for the first
            time during this day, it will take "today's" points
            from the database and count them as yesterday's and "yesterday's"
            as the day before yesterday because they simply haven't moved into the database yet.*/

            var calcPoints = CalculateDailyPoints(points.YesterdayPoints, points.TodayPoints);  
            UpdatePointsForNewDay(points, currentDate, calcPoints, points.YesterdayPoints, points.TodayPoints);
        }
        await _context.SaveChangesAsync();

        return points.TotalPoints;
    }

    private void UpdatePointsForNewDay(Point points, DateOnly currentDate, 
        double newPoints, double YesterdayPoints, double TodayPoints)
    {
        if (points.TodayDate < currentDate)
        {
            points.BeforeYesterdayPoints = YesterdayPoints;
            points.YesterdayPoints = TodayPoints;
            points.TodayPoints = newPoints;
            points.TodayDate = currentDate;
            points.TotalPoints += newPoints;
        }
    }

    private bool IsFirstDayOfSeason(int month, int day)
    {
        return (month == SPRING || month == SUMMER || month == AUTUMN || month == WINTER) && day == FIRS_DAY;
    }

    private bool IsSecondDayOfSeason(int month, int day)
    {
        return (month == SPRING || month == SUMMER || month == AUTUMN || month == WINTER) && day == SECOND_DAY;
    }

    private double CalculateDailyPoints(double beforeYesterdayPoints, double yesterdayPoints)
    {
        return beforeYesterdayPoints + (yesterdayPoints * PERCENTAGE_DIVISION_YESTERDAY);
    }
}
