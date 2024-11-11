namespace EAMDJ.Model;

public record User {
    Guid Id { get; init; }
    string? Username { get; set; }
    string? Password { get; set; }

    // The data model suggests a separate User and Employee entity.
    // Since Users and Employees are 1:1 and User doesn't have any information that allows to differentiate between
    // business owner/normal employee/super admin I think it would be convenient to just combine these two entities.

    // The employee entity has a Name, which I assume is a legal name.
    // I split the legal name into FirstName and LastName.
    string? FirstName { get; set; }
    string? LastName { get; set; }

    // Since I combined User and Employee entities, I'm renaming EmployeeType into UserType.
    UserType UserType { get; set; }

    // The data model suggests fields for when the user starts work and when the user ends work.
    // If we plan to track the employee's schedule in the program, this doesn't seem sufficient, because it isn't
    // granular enough.
    // Just tracking the hour/minute when the employee starts and ends work is not enough, we would also probably need
    // to track what days of the week they work, which may differ per week.
    // That's why I'm omitting the starts_work and ends_work fields.
}