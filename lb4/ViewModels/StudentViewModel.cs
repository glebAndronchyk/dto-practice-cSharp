using System;
using System.ComponentModel;
using lb4.abstractions;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using lb4.abstractions;

namespace lb4.ViewModels
{
    public class StudentViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly List<string> NameFields = new() { "LastName", "FirstName" };

        private DateTime? appliedDate;
        public DateTime? AppliedDate
        {
            get { return appliedDate; }
            set
            {
                appliedDate = value;
                OnPropertyChanged("AppliedDate");
            }
        }

        private string? firstName;
        public string? FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        
        private string? lastName;
        public string? LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string Error => null;
        
        public string this[string columnName]
        {
            get
            {
                if (columnName == "AppliedDate" && AppliedDate == null)
                    return DateValidationString;

                var isLastNameNotValid = columnName == "LastName" && ValidateName(LastName);
                var isFirstNameNotValid = columnName == "FirstName" && ValidateName(FirstName);
                
                if (isLastNameNotValid || isFirstNameNotValid)
                    return NameValidationString;
                
                return null;
            }
        }
        
        public override bool IsFormValid()
        {
            var isValid = NameFields.Any(field => string.IsNullOrEmpty(this[field])) && string.IsNullOrEmpty(this["AppliedDate"]);
            return isValid;
        }

        private bool ValidateName(string? name) =>
            string.IsNullOrEmpty(name) || name.Length < MinNameLength || name.Length > MaxNameLength;
    }
}

