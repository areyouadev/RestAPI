namespace Students.Models.Criteria
{
    using System;

    using Enum;

    public class StudentCriteria
    {
        #region Constructor

        public StudentCriteria(string name, GenderType gender, DateTime birthOfDate)
        {
            Name = name;
            Gender = gender;
            BirthOfDate = birthOfDate;
        }

        #endregion Constructor

        #region Properties

        public string Name { get; set; }
        public GenderType Gender { get; set; }
        public DateTime BirthOfDate { get; set; }

        #endregion Properties

    }
}
