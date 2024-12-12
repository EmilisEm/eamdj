namespace EAMDJ.Model;

public record User
{
	public Guid Id { get; init; }
	public string Username { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;

	// The data model suggests a separate User and Employee entity.
	// Since Users and Employees are 1:1 and User doesn't have any information that allows to differentiate between
	// business owner/normal employee/super admin I think it would be convenient to just combine these two entities.

	// Though in some cases it may be wise to keep the User entity separate from Employee, in that case I think the
	// entity should have some changes.
	// I think renaming the Employee entity to Person or something similar, and keeping only personal data inside it
	// like the legal name, address, etc. could be a good idea.
	// Then UserType stays with the User entity, which becomes an entity used entirely for authentication/authorization.
	// The User entity would then point to a Person entity, which would mean that a Person could have more than one
	// account.

	// The employee entity has a Name, which I assume is a legal name.
	// I split the legal name into FirstName and LastName.
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;

	// Might create an entity for user type, to make user permission levels more customizable.
	// Since I combined User and Employee entities, I'm renaming EmployeeType into UserType.
	public UserType UserType { get; set; }

	// The data model suggests fields for when the user starts work and when the user ends work.
	// If we plan to track the employee's schedule in the program, this doesn't seem sufficient, because it isn't
	// granular enough.
	// Just tracking the hour/minute when the employee starts and ends work is not enough, we would also probably need
	// to track what days of the week they work, which may differ per week.
	// That's why I'm omitting the starts_work and ends_work fields.

	// The data model didn't specify, but I think it would make sense to add a field for which business this User
	// belongs to.
	// I'm making it nullable, because I think Admin type users wouldn't be related to a specific business.
	public Guid? BusinessId { get; set; }
	public virtual Business? Business { get; set; }
}