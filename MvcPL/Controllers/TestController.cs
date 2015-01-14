using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces.Objects;
using BLL.Interfaces.Services;

namespace MvcPL.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        //
        // GET: /Test/
        private readonly ITestService _testService;
        private readonly IVariantService _variantService;
        private readonly IQuestionService _questionService;

        public TestController(ITestService testService, IVariantService variantService, IQuestionService questionService)
        {
            _testService = testService;
            _variantService = variantService;
            _questionService = questionService;
        }

        [HttpGet]
        public ActionResult TestResult(int id)
        {
            var test = _testService.GetById(id);
            
            return View(test);
        }

        [HttpPost]
        public ActionResult TestResult(Test model)
        {
            var test = _testService.GetById(model.Id);
            int n = 0;
            foreach (var question in test.Questions)
            {
                var modelQuestion = model.Questions.Find(q => q.Id == question.Id);
                if (modelQuestion.SelectedVariant.Count(var => var) == question.NumberAnsers)
                    n++;
            }
            ViewBag.N = n;
            return View("TestComplete", test);
        }

    }
}
