using CourseWorkWeb.Models.Entity.Medicines;
using MediatR;
using System.Collections;

namespace CourseWorkWeb.Core.CQRS.Medicines.Queries
{
    public record GetMedicinesQuery() : IRequest<IEnumerable<Medicine>?>;
}
