using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Objects;
using BLL.Interfaces.Services;

namespace MvcPL.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private readonly IUserService _userService;
        private readonly ITestService _testService;
        private readonly IQuestionService _questionService;
        private readonly IVariantService _variantService;
        public AdminController(IUserService userService, ITestService testService, IQuestionService questionService, IVariantService variantService)
        {
            _userService = userService;
            _testService = testService;
            _questionService = questionService;
            _variantService = variantService;
        }

        public ActionResult TestDelete(int id)
        {
            _testService.Delete(_testService.GetById(id));

            return RedirectToAction("TestManager");
        }

        [HttpGet]
        public ActionResult UserManager()
        {
            ViewBag.Users = _userService.GetAll();  

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeleteUser(int id)
        {
            _userService.Delete(_userService.GetById(id));
            _userService.Save();
            return RedirectToAction("UserManager");
        }

        public ActionResult TestManager()
        {
            ViewBag.Tests = _testService.GetAll();

            return View();
        }

        [HttpGet]
        public ActionResult CreateTest()
        {
            var test = new Test();
            test.Id = _testService.GetMaxId() + 1;
            return View(test);
        }

        public ActionResult DeleteQuestion(int id)
        {
            var question = _questionService.GetById(id);
            var test = _testService.GetById(question.TestId);
            _questionService.Delete(question);

            return RedirectToAction("TestEditor", new {id = test.Id.ToString()});
        }

        [HttpPost]
        public ActionResult CreateTest(Test test)
        {
            test.Id = _testService.GetMaxId() + 1;
            _testService.Add(test);

            return RedirectToAction("CreateQuestions", "Admin", new { id = test.Id.ToString() });
        }

        [HttpGet]
        public ActionResult CreateQuestions(int id)
        {
            var question = new Question();
            question.Id = _questionService.GetMaxId() + 1;
            question.TestId = id;
            return View(question);
        }

        public ActionResult RedirectToQuestion(int id)
        {
            var question = _questionService.GetById(id);
            return RedirectToAction("CreateQuestions", "Admin", new {id = question.TestId.ToString()});
        }

        [HttpPost]
        public ActionResult CreateQuestions(Question question, int id)
        {
            question.Id = _questionService.GetMaxId() + 1;
            question.TestId = id;
            _questionService.Add(question);

            return RedirectToAction("CreateQuestions");
        }

        public ActionResult GetAllQuestions(int id)
        {
            var test = _testService.GetById(id);

            return PartialView("GetAllQuestions", test);
        }

        [HttpGet]
        public ActionResult CreateVariants(int id)
        {
            var variant = new Variant();
            variant.Id = _variantService.GetMaxId() + 1;
            variant.QuestionId = id;

            return View(variant);
        }

        [HttpPost]
        public ActionResult CreateVariants(Variant variant, int id)
        {
            variant.Id = _variantService.GetMaxId() + 1;
            variant.QuestionId = id;
            _variantService.Add(variant);
            return RedirectToAction("CreateVariants");
        }

        [HttpGet]
        public ActionResult TestEditor(int id)
        {
            var test = _testService.GetById(id);

            return View(test);
        }

 

        [HttpPost]
        public ActionResult TestEditor(Test test)
        {
            _testService.Change(test.Id, test);

            return View(test);
        }

        [HttpGet]
        public ActionResult QuestionEditor(int id)
        {
            var question = _questionService.GetById(id);

            return View(question);
        }

        [HttpPost]
        public ActionResult QuestionEditor(Question question)
        {
            _questionService.Change(question.Id, question);
            var qustionNew = _questionService.GetById(question.Id);

            return View(qustionNew);
        }

        [HttpGet]
        public ActionResult VariantEditor(int id)
        {
            var variant = _variantService.GetById(id);

            return View(variant);
        }

        [HttpPost]
        public ActionResult VariantEditor(Variant variant)
        {
            _variantService.Change(variant.Id, variant);

            var variantNew = _variantService.GetById(variant.Id);

            return View(variantNew);
        }
    }
}
