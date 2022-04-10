using System;

namespace KIT206
{
    public class StudentGroup
	{
		//Private Fields
		private int _groupID;
		private string _groupName;


		//Public properties
		public int GroupID
        {
			get => default;
			set
            {
				_groupID = value;
            }
        }
		public string GroupName
        {
			get => default;
            set
            {
				_groupName = value;
            }
        }
		//either generates a number and checks it doesnt exists or find the next sequential one
		public StudentGroup(string name)
		{
			//Generate group ID and then set to groupID (5 is placeholder)

			_groupID = GenerateGroupID();
			_groupName = name;
		}

        private int GenerateGroupID()
        {
            return 0;
        }

        public void AddClass()
		{
			throw new System.NotImplementedException();
		}

		public void AddMeeting()
		{
			throw new System.NotImplementedException();
		}

		public void EditGroup()
		{
			throw new System.NotImplementedException();
		}

		public static StudentGroup GetGroup(int id)
        {
			throw new System.NotImplementedException();

		}
	}
}