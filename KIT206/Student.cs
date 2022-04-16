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

        //Get data from database, maybe just take in ID? 
        public Student(string f_name, string l_name, int id)
		{
            //First or
            //StudentID = id;
            //FirstName = name;
            //Second? I prefer second because its apart of the class but other classes should use the Public ones
			_studentID = id;
			_firstName = f_name;
            _lastName = l_name;
		}

        public Student(int id, string f_name, string l_name, int group_id, string title, Campus campus, string email, Category category)
		{
            //First or
            //StudentID = id;
            //FirstName = name;
            //Second? I prefer second because its apart of the class but other classes should use the Public ones
			_studentID = id;
            _firstName = f_name;
            _lastName = l_name;
            _groupID = group_id;
            _title = title;
            _campus = campus;
            _email = email;
            _category = category;

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

		public StudentGroup AddGroup(string name)
		{
            StudentGroup group = new StudentGroup(name);
            StudentGroup = group.GroupID;
            return group;
		}

		public void AddStudentDetails()
		{
			throw new System.NotImplementedException();
		}
        
		public void EditStudentGroup()
		{
			foreach(Student student in Storage.Students)
            {
                if (student.StudentID == StudentID)
                    student.StudentGroup = -1;
            }
		}
        public string GetStudentString()
        {
            if (Email != null)
                return ToString("full");
            else
                return ToString(" ");
        }
		public string ToString(string type)
        {
            if (type == "full")

                return ("Name: " + Title.ToString() +" "+ FirstName + " " + LastName + ", Student ID: " + StudentID + ", in group " + Storage.GetGroup(StudentGroup).GroupName + " Completing their " + Category.ToString() + " on the " + Campus.ToString() + " Campus. Their Email is " + Email);
            else
                return ("Name: " + FirstName + " " + LastName + ", Student ID: " + StudentID);
        }
	}
}