using ChaikaTechTestTask.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTechTestTask.Core.Points;

public class DailyPointsCalculator
{
    #region const
    private const int POINTS_FIRST_DAY_MONTH = 2;
    private const int POINTS_SECOND_DAY_MONTH = 3;

    private const int SPRING = 4;
    private const int SUMMER = 6;
    private const int AUTUMN = 9;
    private const int WINTER = 12;

    private const int FIRS_DAY = 1;
    private const int SECOND_DAY = 2;
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

        if ((month == SPRING && day == FIRS_DAY) || (month == SUMMER && day == FIRS_DAY) || 
            (month == AUTUMN && day == FIRS_DAY) || (month == WINTER && day == FIRS_DAY))
        {
            if (points.TodayDate < currentDate)
            {
                points.BeforeYesterdayPoints = points.YesterdayPoints;
                points.YesterdayPoints = points.TodayPoints;
                points.TodayPoints = POINTS_FIRST_DAY_MONTH;
                points.TodayDate = currentDate;
                points.TotalPoints += POINTS_FIRST_DAY_MONTH; // ???
            }
        }
        else if ((month == SPRING && day == SECOND_DAY) || (month == SUMMER && day == SECOND_DAY) ||
            (month == AUTUMN && day == SECOND_DAY) || (month == WINTER && day == SECOND_DAY))
        {
            if (points.TodayDate < currentDate)
            {
                points.BeforeYesterdayPoints = points.YesterdayPoints;
                points.YesterdayPoints = points.TodayPoints;
                points.TodayPoints = POINTS_SECOND_DAY_MONTH;
                points.TodayDate = currentDate;
                points.TotalPoints += POINTS_SECOND_DAY_MONTH; // ???
            }
        }
        else
        {
            if (points.TodayDate < currentDate)
            {
                points.BeforeYesterdayPoints = points.YesterdayPoints;
                points.YesterdayPoints = points.TodayPoints;
                points.TodayPoints = CalculateDailyPoints(points.BeforeYesterdayPoints, points.YesterdayPoints);
                points.TodayDate = currentDate;
                points.TotalPoints += points.TodayPoints; // ???
            }
        }
        await _context.SaveChangesAsync();

        return points.TotalPoints;
    }

    private double CalculateDailyPoints(double beforeYesterdayPoints, double yesterdayPoints)
    {
        return beforeYesterdayPoints + (yesterdayPoints * 0.6);
    }
}
