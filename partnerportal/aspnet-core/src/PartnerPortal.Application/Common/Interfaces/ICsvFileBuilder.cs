using PartnerPortal.Application.TodoLists.Queries.ExportTodos;

namespace PartnerPortal.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);

        byte[] BuildRequisitionsFile(IEnumerable<RequisitionRecord> records);
    }
}
