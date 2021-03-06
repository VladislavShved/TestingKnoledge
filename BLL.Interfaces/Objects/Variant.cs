﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace BLL.Interfaces.Objects
{
    public class Variant : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }

        public bool IsCorrect { get; set; }
        public virtual Question Question { get; set; }
    }
}
