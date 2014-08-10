namespace SchoolOrganisation
{
    using System.Collections.Generic;

    public class School
    {
        IList<SchoolClass> classes;

        public School()
        {
            this.classes = new List<SchoolClass>();
        }

        public SchoolClass AddClass
        {
            set
            {
                this.classes.Add(value);
            }
        }

        public override string ToString()
        {
            return string.Join("\n", this.classes);
        }
    }
}
