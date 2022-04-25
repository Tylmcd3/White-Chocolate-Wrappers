using System;
using System.Collections.Generic;

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
            get
            {
                return _groupID;
            }
            set
            {
                _groupID = value;
            }
        }
        public string GroupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
            }
        }
        ///<summary>
		///Creates a new StudentGroup
		///</summary>
        public StudentGroup(int id, string name)
        {
            //Generate group ID and then set to groupID (5 is placeholder)

            _groupID = id;
            _groupName = name;
        }

        public override string ToString()
        {
            return ($"{_groupName} (ID: {_groupID})");
        }
       
    }
}