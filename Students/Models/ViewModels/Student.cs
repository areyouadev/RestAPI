namespace Students.Models
{
    using System;

    using Enum;

    public class Student
    {
        #region Constructor

        public Student(int id, string name, GenderType gender, DateTime birthOfDate)
        {
            Id = id;
            Name = name;
            Gender = gender;
            BirthOfDate = birthOfDate;
        }

        #endregion Constructor

        #region Properties

        public int Id { get; init; }
        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public DateTime BirthOfDate { get; set; }

        #endregion Properties
    }
}
