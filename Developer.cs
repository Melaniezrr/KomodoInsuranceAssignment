using System;
namespace KomodoInsurance
{
    // POCO: Plain Ol' Class Object
    public class Developer
    {
        // properties of the class
        // get is for retrieving the value
        // set is for changing the value
        public string Id { get; set; }
        public string Name { get; set; }
        public string HasPluralsightAccess { get; set; }
        // constructor: The method to run when the class is
        //   instantiated with the new keyword: Dog luna = new Dog();
        //   has the same name as the class but without the class keyword
        public Developer(string IdValue, string NameValue, string HasPluralsightAccessValue)
        {
            // Set's the initial values of these properties
            // 1    2      3   4    5      6       7
            // Dog luna = new Dog('123', 'Luna', false);
            // 1 type for the new variable
            // 2 variable name
            // 3 the new keyword is for creating a new instance of a class
            // 4 the name of the class you want to use to create this new thing
            // 5 the value of id for the new Developer
            // 6 the value of name for the new Developer
            // 7 the value of hasPluralsightAccess for the new Developer
            Id = IdValue;
            Name = NameValue;
            HasPluralsightAccess = HasPluralsightAccessValue;
        }
    }
}