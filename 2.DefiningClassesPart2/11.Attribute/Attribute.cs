//Create a [version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds 
//a version in the format major.minor (e.g. 2.11). Apply the version attribute to a sample class and display its version at runtime.
namespace UsingAttribute
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class |
        AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method)]
    class Version : System.Attribute
    {
        private int major;
        private int minor;

        public Version(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major
        {
            get { return this.major; }
            private set
            {
                Validate(value);
                this.major = value;
            }
        }

        public int Minor
        {
            get { return this.minor; }
            private set
            {
                Validate(value);
                this.minor = value;
            }
        }

        private void Validate(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Version cannot contain negative numbers!");
            }
        }
    }
}