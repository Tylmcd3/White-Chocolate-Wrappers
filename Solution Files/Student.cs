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
        //Two Constructors, one is for Students who havnt added details and the other is for complete students 
        public Student(int id, string f_name, string l_name )
		{
			_studentID = id;
			_firstName = f_name;
            _lastName = l_name;
		}

        public Student(int id, string f_name, string l_name, int group_id, string title,string phone, Campus campus, string email, Category category)
		{
			_studentID = id;
            _firstName = f_name;
            _lastName = l_name;
            _groupID = group_id;
            _title = title;
            _campus = campus;
            _email = email;
            _category = category;
            _phone = phone;

        }
        
        public string ToString(string type)
        {
            if (type == "full")
                if (StudentGroup != 0)
                    return "Name: " + Title.ToString() + " " + FirstName + " " + LastName + ", Student ID: " + StudentID + ", in group " + StorageAdapter.GetGroup(StudentGroup).GroupName + " Completing their " + Category.ToString() + " on the " + Campus.ToString() + " Campus. Their Email is " + Email;
                else
                    return "Name: " + Title.ToString() + " " + FirstName + " " + LastName + ", Student ID: " + StudentID + ",  " + "Completing their " + Category.ToString() + " on the " + Campus.ToString() + " Campus. Their Email is " + Email;
            else
                return "Name: " + FirstName + " " + LastName + ", Student ID: " + StudentID;
        }

        //Needs to be added to the controller
        //This needs to be refactored to be getGroup, if group == NULL then add
    }
}