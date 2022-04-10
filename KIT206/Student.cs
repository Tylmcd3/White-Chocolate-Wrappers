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
            get => default;
            set
            {
                _studentID = value;
            }
        }
        public string FirstName
        {
            get => default;
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get => default;
            set
            {
                _lastName = value;
            }
        }
        public string Title
        {
            get => default;
            set
            {
                _title = value;
            }
        }
        public Campus Campus
        {
            get => default;
            set
            {
                _campus = value;
            }
        }
        public string Phone
        {
            get => default;
            set
            {
                _phone = value;
            }
        }
        public string Email
        {
            get => default;
            set
            {
                _email = value;
            }
        }
        public string Photo
        {
            get => default;
            set
            {
                _photo = value;
            }
        }
        public Category Category
        {
            get => default;
            set
            {
                _category = value;
            }
        }

        //Get data from database, maybe just take in ID? 
        public Student(string name, int id)
		{
            //First or
            StudentID = id;
            FirstName = name;
            //Second?
			_studentID = id;
			_firstName = name;
		}

		public StudentGroup StudentGroup
		{
			get => default;
			set
			{
			}
		}

		public void AddGroup()
		{
			throw new System.NotImplementedException();
		}

		public void AddStudentDetails()
		{
			throw new System.NotImplementedException();
		}

		public void EditStudentGroup()
		{
			throw new System.NotImplementedException();
		}

		public string ToString()
        {
			return (_firstName + " " + _lastName + ", " + _studentID);
        }
	}
}