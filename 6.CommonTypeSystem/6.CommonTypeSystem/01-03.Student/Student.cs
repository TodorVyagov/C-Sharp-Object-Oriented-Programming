namespace StudentActions
{
    using System;
    using System.Text.RegularExpressions;

    public class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private uint ssn;
        private string address;
        private string mobilePhone;
        private string email;
        private int course;

        public Student(string firstName, string middleName, string lastName, uint ssn, string address, string mobilePhone, 
            string email, int course, Specialty specialty, University university, Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        #region Properties

        public Specialty Specialty { get; private set; }

        public University University { get; private set; }

        public Faculty Faculty { get; private set; }

        private string FirstName
        {
            set
            {
                ValidateName(value);
                this.firstName = value;
            }
        }

        private string MiddleName
        {
            set
            {
                ValidateName(value);
                this.middleName = value;
            }
        }

        private string LastName
        {
            set
            {
                ValidateName(value);
                this.lastName = value;
            }
        }

        public string FullName
        {
            get
            {
                return this.firstName + " " + this.middleName + " " + this.lastName;
            }
        }

        public uint SSN
        {
            get
            {
                return this.ssn;
            }
            private set
            {
                if (value.ToString().Length != 9) //check for SSN length
                {
                    throw new ArgumentException("SSN number must contain exactly 9 digits!");
                }

                foreach (var digit in value.ToString())
                {
                    if (!char.IsDigit(digit)) //if current char is not digit
                    {
                        throw new ArgumentException("SSN number has to contain only digits! No other symbols are allowed!");
                    }
                }

                this.ssn = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Address cannot be empty!");
                }

                this.address = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }
            private set
            {
                for (int digit = 0; digit < value.Length; digit++)
                {
                    if (!char.IsDigit(value[digit]) && !(value[digit] == '+' && digit == 0))
                    {
                        throw new ArgumentException("Incorrect phone number! Phone must contain only digits and may have leading '+'");
                    }
                }

                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            private set
            {
                if (!Regex.IsMatch(value, @"[\w.]{2,20}@[\w]{2,20}[.]{1}[\w.]{2,6}")) //taken from homework - Strings and text processing
                {
                    throw new ArgumentException("Invalid e-mail!");
                }

                this.email = value;
            }
        }

        public int Course
        {
            get
            {
                return this.course;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Course must be bugger than zero!");
                }

                this.course = value;
            }
        }
        #endregion

        #region Methods
        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be empty!");
            }

            foreach (var letter in name)
            {
                if (!char.IsLetter(letter)) //if char is not letter
                {
                    throw new ArgumentException("Name must contain only letters!");
                }
            }
        }

        public override bool Equals(object param)
        {
            Student student = param as Student;

            if (student == null)
            {
                return false;
            }

            if (student.FullName != this.FullName)
            {
                return false;
            }

            if (student.SSN != this.SSN)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            result.AppendLine("Name: " + this.FullName);
            result.AppendLine("SSN: " + this.SSN);
            result.AppendLine("Address: " + this.Address);
            result.AppendLine("Phone: " + this.MobilePhone);
            result.AppendLine("e-mail: " + this.Email);
            result.AppendLine("Course: " + this.Course);
            result.AppendLine("University: " + this.University);
            result.AppendLine("Faculty: " + this.Faculty);
            result.AppendLine("Specialty: " + this.Specialty);

            return result.ToString();
        }

        public override int GetHashCode()
        {
            return this.FullName.GetHashCode() ^ this.SSN.GetHashCode();
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return Student.Equals(student1, student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(Student.Equals(student1, student2));
        }

        public Student Clone()
        {
            Student student = new Student(this.firstName, this.middleName, this.lastName, this.SSN, this.Address, this.MobilePhone,
                this.Email, this.Course, this.Specialty, this.University, this.Faculty);
            return student;//there are no referent types, so copying is easy
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public int CompareTo(Student other)
        {
            if (this.FullName.CompareTo(other.FullName) != 0)
            {
                return this.FullName.CompareTo(other.FullName);
            }
            else
            {
                return this.SSN.CompareTo(other.SSN);
            }
        }
        #endregion

    }
}
