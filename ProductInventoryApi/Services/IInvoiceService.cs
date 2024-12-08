public interface IInvoiceService
{
    Task<APIResponse<IEnumerable<InvoiceResponseDTO>>> GetAllInvoicesAsync();
    Task<APIResponse<InvoiceResponseDTO>> GetInvoiceByIdAsync(int id);
    Task<APIResponse<InvoiceResponseDTO>> CreateInvoiceAsync(InvoiceRequestDTO invoiceRequest);
    Task<APIResponse<InvoiceResponseDTO>> UpdateInvoiceAsync(int id, InvoiceRequestDTO invoiceRequest);
    Task<APIResponse<bool>> DeleteInvoiceAsync(int id);
}
