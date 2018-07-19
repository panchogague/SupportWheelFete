using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SupportWheelFate.Classes;
using SupportWheelFate.Interfaces;

namespace SupportWheelFate.Controllers
{
    [Route("api/[controller]")]
    public class ScheduleController : Controller
    {
        private static string[] _dayNames = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
        private readonly IOptions<ScheduleOptions> _optionsAccessor;
        private readonly IScheduleService _scheduleGeneratorService;

        public ScheduleController(IScheduleService scheduleService,
         IOptions<ScheduleOptions> optionsAccessor)
        {
            _scheduleGeneratorService = scheduleService;
            _optionsAccessor = optionsAccessor;
        }

        public IActionResult GenerateSchedule()
        {
            var shifts = _scheduleGeneratorService.Generate(_optionsAccessor.Value.ShiftsPerPeriod, _optionsAccessor.Value.ShiftsPerEngineerPerPeriod);

            // TODO create a Mapper profile for this
            // Map the shifts to the Day View Model
            var shiftsPerDay = _optionsAccessor.Value.ShiftsPerPeriod / _optionsAccessor.Value.ShiftDays;
            var days = new List<DayView>();
            for (int i = 0; i < _optionsAccessor.Value.ShiftDays; i++)
            {
                days.Add(new DayView
                {
                    Name = _dayNames[i % 5],
                    Shifts = shifts.Skip(i * shiftsPerDay).Take(shiftsPerDay).ToList(),
                    WeekNumber = i < 5 ? 1 : 2
                });
            }

            return Json(days);
            //return Json(new { Days = 10 });
        }
    }
}
