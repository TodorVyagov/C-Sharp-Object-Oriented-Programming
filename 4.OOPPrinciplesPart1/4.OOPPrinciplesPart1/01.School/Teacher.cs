namespace SchoolOrganisation
{
    using System.Collections.Generic;

    public class Teacher : Person, ICommentable
    {
        private IList<Discipline> teachingDisciplines;
        public IList<string> comments = new List<string>();

        public Teacher(string firstName, string lastName, IList<Discipline> disciplines)
            : base(firstName, lastName)
        {
            this.Disciplines = disciplines;
        }

        public IList<Discipline> Disciplines
        {
            get { return this.teachingDisciplines; }
            set { this.teachingDisciplines = value; }
        }

        public Discipline AddDiscipline
        {
            set { this.teachingDisciplines.Add(value); }
        }

        public Discipline RemoveDiscipline
        {
            set { this.teachingDisciplines.Remove(value); }
        }

        public string Comments
        {
            get {return "Comments: " + string.Join("\n", this.comments); }
        }
        
        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }

        public void ClearComments()
        {
            this.comments.Clear();
        }

        public override string ToString()
        {
            return this.Name + " Teaches:\n\t" + string.Join("\n\t", teachingDisciplines);
        }
    }
}
