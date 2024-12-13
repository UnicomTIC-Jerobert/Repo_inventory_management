public interface IInvoiceService
{
    Task<APIResponse<IEnumerable<InvoiceResponseDTO>>> GetAllInvoicesAsync();
    Task<APIResponse<InvoiceResponseDTO>> GetInvoiceByIdAsync(Guid id);
    Task<APIResponse<InvoiceResponseDTO>> CreateInvoiceAsync(InvoiceRequestDTO invoiceRequest);
    Task<APIResponse<InvoiceResponseDTO>> UpdateInvoiceAsync(Guid id, InvoiceRequestDTO invoiceRequest);
    Task<APIResponse<bool>> DeleteInvoiceAsync(Guid id);
}
