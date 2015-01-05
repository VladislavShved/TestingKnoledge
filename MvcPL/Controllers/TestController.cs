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
        private int testId;

        public TestController(ITestService testService, IVariantService variantService, IQuestionService questionService)
        {
            _testService = testService;
            _variantService = variantService;
            _questionService = questionService;
        }

        [HttpGet]
        public ActionResult TestResult(int id)
        {
            testId = id;
            var test = _testService.GetById(testId);
            ViewBag.Test = test;
            ViewBag.Questions = test.Questions;
            
            return View(test);
        }

        [HttpPost]
        public string TestResult(Test model)
        {
            var test = _testService.GetById(model.Id);
            var n = (from question in model.Questions let qt = _questionService.GetById(question.Id) let N = test.Questions.Find(q => q.Id == question.Id).Variants.Count(var => var.IsCorrect) let k = question.SelectedVariant.Count(variant => variant) let correct = question.SelectedVariant.Where((t, i) => qt.Variants[i].IsCorrect && t).Count()
                     where k == N && correct == N 
                     select N).Count();
            return "Тест пройден, правильных ответов: " + n + " из " + model.Questions.Count;
        }

    }
}
