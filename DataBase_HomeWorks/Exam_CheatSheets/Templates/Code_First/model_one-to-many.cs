namespace MySolution.Model
{
    using System;
    using System.Collections.Generic;

    public class MyClass
    {
        private ICollection<MyProperty> myproperty;

        public MyClass()
        {
            this.myproperty = new HashSet<MyProperty>();
        }

        public int MyClassId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<MyProperty> MyProperty
        {
            get { return this.myproperty; }
            set { this.myproperty = value; }
        }
    }
}
