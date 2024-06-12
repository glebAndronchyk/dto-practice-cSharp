using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using lb4.abstractions;

namespace lb4.ViewModels;

// TODO: currently this is broken
public class PublicationViewModel : ViewModelBase, IDataErrorInfo
{
    private readonly List<string> NameFields = new() { "Student", "Achievement" };
    
        private Student? student;
        public Student? Student
        {
            get { return student; }
            set
            {
                student = value;
                OnPropertyChanged("Student");
            }
        }

        private EScientificAchievement? achievement;
        public EScientificAchievement? Achievement
        {
            get { return achievement; }
            set
            {
                achievement = value;
                OnPropertyChanged("Achievement");
            }
        }
    

        public string Error => null;
        
        public string this[string columnName]
        {
            get
            {
                if ((columnName == "Student" && string.IsNullOrEmpty(columnName)) ||
                    (columnName == "Achievement" && string.IsNullOrEmpty(columnName)))
                    return FieldRequiredString;

                return null;
            }
        }
        
        public override bool IsFormValid()
        {
            var isValid = NameFields.Any(field => string.IsNullOrEmpty(this[field]));
            return isValid;
        }
}