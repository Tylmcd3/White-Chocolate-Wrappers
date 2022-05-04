using System;
namespace KIT206
{
    public class Student
	{
        //Private Fields
		private int _studentID;
		private string _firstName;
		private string _lastName;
		private int _groupID;
		private string _title;
		private Campus _campus;
		private string _phone;
		private string _email;
		private string _photo;
		private Category _category;

        //Public Properties
        //Can Condense these later
        public int StudentID
        {
            get=> _studentID;
            set
            {
                _studentID = value;
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
            }
        }
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
            }
        }
        public Campus Campus
        {
            get => _campus;
            set
            {
                _campus = value;
            }
        }
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
            }
        }
        public string Photo
        {
            get => _photo;
            set
            {
                _photo = value;
            }
        }
        public Category Category
        {
            get => _category;
            set
            {
                _category = value;
            }
        }
        public int StudentGroup
        {
            get
            {
                return _groupID;
            }
            set
            {
                _groupID = value;
            }
        }
        ///<summary>
		///Creates a new Student Object given ID and name
		///</summary>
        public Student(int id, string firstName, string lastName, int groupID )
		{
			_studentID = id;
			_firstName = firstName;
            _lastName = lastName;
            _campus = Campus.None;
            _category = Category.None;
            _groupID = groupID;
		}
        ///<summary>
		///Creates a new Student Object given full Student Details. 
        ///If Details are empty, sets field to empty value 
		///</summary>
        public Student(int id, string firstName, string lastName, int group_id, string title,string phone, Campus campus, string email, Category category, string photo)
		{
			_studentID = id;
            _firstName = firstName;
            _lastName = lastName;
            _groupID = group_id;
            _title = title ?? "";
            _campus = campus;
            _email = email ?? "";
            _category = category;
            _phone = phone ?? "";
            _photo = photo;
        }
        ///<summary>
		///Returns a string containg a students name and ID
		///</summary>
        public override string ToString()
        {
            return ($"{_firstName} {_lastName} (ID: {_studentID})");
        }
        ///<summary>
		///Returns a string containg a students full details
		///</summary>
        public string ToStringFull()
        {
            string toReturn;
            toReturn = ($"{_firstName} {_lastName} (ID: {_studentID})");
            if (_title != "")
            {
                toReturn = ($"{_title} " + toReturn + $", " +
                    $"Completing their {_category.ToString()} at {_campus.ToString()}. " +
                    $"Contact at {_email} or {_phone}.");
            }
            if(_groupID != -1)
            {
                toReturn += $" They are in group {_groupID}";
            }

            return toReturn;
        }

    }
}