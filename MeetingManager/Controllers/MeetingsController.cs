using MeetingManager.Data;
using MeetingManager.Models;
using MeetingManager.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MeetingManager.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly MeetingDbContext dbContext;

        public MeetingsController(MeetingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddMeetingViewModel viewModel)
        {
            var meeting = new Meeting
            {
                Title = viewModel.Title,
                Time = viewModel.Time,
                Location = viewModel.Location,
                Description = viewModel.Description

            };
            await dbContext.Meetings.AddAsync(meeting);
            await dbContext.SaveChangesAsync();
            return View();

        }
        [HttpGet]

        public async Task<IActionResult> List()
        {
            var meetings = await dbContext.Meetings.ToListAsync();
            return View(meetings);
        }
        [HttpGet]

        public async Task<IActionResult> Edit(Guid Id)
        {
            var meeting= await dbContext.Meetings.FindAsync(Id);
            return View(meeting);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Meeting viewModel)
        {
            var meeting = await dbContext.Meetings.FindAsync(viewModel.Id);
            
            if(meeting is not null)
            {
                meeting.Title = viewModel.Title;
                meeting.Time = viewModel.Time;
                meeting.Location = viewModel.Location;
                meeting.Description = viewModel.Description;

                await dbContext.SaveChangesAsync();
            }
                return RedirectToAction("List", "Meetings");

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Meeting viewModel) { 
          var meeting = await dbContext.Meetings
                .AsNoTracking()
                .FirstOrDefaultAsync(x=> x.Id==viewModel.Id);
            if (meeting is not null)
            {
                dbContext.Meetings.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Meetings");
        }
        } }
