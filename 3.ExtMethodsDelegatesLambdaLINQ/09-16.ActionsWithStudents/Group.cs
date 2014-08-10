namespace ActionsWithStudents
{
    using System;

    public class Group
    {
        public int GroupNumber { get; private set; }
        public string DepartmentName { get; private set; }

        public Group(int groupNumber, string department)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = department;
        }
    }
}
