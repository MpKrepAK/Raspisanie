using System.ComponentModel.DataAnnotations.Schema;

namespace Raspisanie.Models.Database.Entitys;

public class GroupSubjectTime
{
    public long Id { get; set; }
    public int TotalTime { get; set; }
    public int PassedTime { get; set; }
    [ForeignKey("Subgroup")]
    public long SubgroupId { get; set; }
    public Subgroup Subgroup { get; set; }
    [ForeignKey("Subject")]
    public long SubjectId { get; set; }
    public Subject Subject { get; set; }
}