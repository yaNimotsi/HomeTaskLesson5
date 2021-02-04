using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTaskLesson5_5
{
    class ToDo
    {
        string title;
        bool isDone;

        public ToDo()
        {

        }
        public ToDo(string title, bool isDone)
        {
            Title = title;
            IsDone = isDone;
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public bool IsDone
        {
            get { return isDone; }
            set { isDone = value; }
        }
    }
}
