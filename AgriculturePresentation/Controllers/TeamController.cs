using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IValidator<Team> _validator;
        public TeamController(ITeamService teamService, IValidator<Team> validator)
        {
            _teamService = teamService;
            _validator = validator;
        }
        public IActionResult Index()
        {
            var result = _teamService.GetListAll();
            return View(result);

        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();

        }

        [HttpPost]

        public async Task<IActionResult> AddTeam(Team team)
        {

            ValidationResult result = await _validator.ValidateAsync(team);
            if (result.IsValid)
            {
                _teamService.Insert(team);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        public IActionResult DeleteTeam(int id)
        {
            var result = _teamService.GetById(id);
            _teamService.Delete(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateTeam(int id)
        {
            var result = _teamService.GetById(id);
            return View(result);
            
        }
        [HttpPost]
        public IActionResult UpdateTeam(Team team)
        {
            _teamService.Update(team);
            return RedirectToAction("Index");
        }


    }
}
