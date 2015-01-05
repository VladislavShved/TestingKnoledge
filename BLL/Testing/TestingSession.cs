using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Objects;

namespace BLL.Testing
{
    public class TestingSession
    {
        public User CurrentUser { get; set; }
        public Test CurrentTest { get; set; }
        public int NumberQuestions { get; private set; }
        public int CorrectAnswers { get; private set; }

        public TestingSession()
        {
            NumberQuestions = CurrentTest.Questions.Count;
            CorrectAnswers = 0;

        }

        
    }
}
