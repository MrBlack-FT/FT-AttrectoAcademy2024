namespace Academy_2024.Models
{
    public class Course
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public ICollection<User> Users { get; set; } = [];

        //public User? Author { get; set; }
        /*
        Unable to create a 'DbContext' of type ''.
        The exception 'Unable to determine the relationship represented by navigation 'Course.Author' of type 'ICollection<User>'.
        Either manually configure the relationship, or ignore this property using the '[NotMapped]' attribute or by using 'EntityTypeBuilder.
        Ignore' in 'OnModelCreating'.' was thrown while attempting to create an instance.
        For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728 
        */
    }
}
