namespace Application.DTOs;

public class CompanyDto : BaseCompanyDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsActive { get; set; }
}
