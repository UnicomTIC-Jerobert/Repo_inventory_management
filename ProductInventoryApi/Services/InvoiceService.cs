using AutoMapper;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IInvoiceItemRepository _invoiceItemRepository;
    private readonly IMapper _mapper;

    public InvoiceService(IInvoiceRepository invoiceRepository, IInvoiceItemRepository invoiceItemRepository, IMapper mapper)
    {
        _invoiceRepository = invoiceRepository;
        _invoiceItemRepository = invoiceItemRepository;
        _mapper = mapper;
    }

    public async Task<APIResponse<IEnumerable<InvoiceResponseDTO>>> GetAllInvoicesAsync()
    {
        var invoices = await _invoiceRepository.GetAllAsync();
        var mappedInvoices = _mapper.Map<IEnumerable<InvoiceResponseDTO>>(invoices);

        return new APIResponse<IEnumerable<InvoiceResponseDTO>>
        {
            Success = true,
            Payload = mappedInvoices,
            Title = "Fetched all invoices successfully"
        };
    }

    public async Task<APIResponse<InvoiceResponseDTO>> GetInvoiceByIdAsync(int id)
    {
        var invoice = await _invoiceRepository.GetByIdAsync(id);

        if (invoice == null)
        {
            return new APIResponse<InvoiceResponseDTO>
            {
                Success = false,
                Title = "Invoice not found",
                Errors = new List<string> { $"No invoice found with ID: {id}" }
            };
        }

        var mappedInvoice = _mapper.Map<InvoiceResponseDTO>(invoice);

        return new APIResponse<InvoiceResponseDTO>
        {
            Success = true,
            Payload = mappedInvoice,
            Title = "Fetched invoice successfully"
        };
    }

    public async Task<APIResponse<InvoiceResponseDTO>> CreateInvoiceAsync(InvoiceRequestDTO invoiceRequest)
    {
        var invoice = _mapper.Map<Invoice>(invoiceRequest);

        using var transaction = await _invoiceRepository.BeginTransactionAsync();
        try
        {
            var createdInvoice = await _invoiceRepository.AddAsync(invoice);

            foreach (var item in invoiceRequest.InvoiceItems)
            {
                var invoiceItem = _mapper.Map<InvoiceItem>(item);
                invoiceItem.InvoiceId = createdInvoice.Id;
                await _invoiceItemRepository.AddAsync(invoiceItem);
            }

            await transaction.CommitAsync();

            var response = _mapper.Map<InvoiceResponseDTO>(createdInvoice);
            return new APIResponse<InvoiceResponseDTO>
            {
                Success = true,
                Payload = response,
                Title = "Invoice created successfully"
            };
        }
        catch
        {
            await transaction.RollbackAsync();
            return new APIResponse<InvoiceResponseDTO>
            {
                Success = false,
                Title = "Invoice creation failed",
                Errors = new List<string> { "An error occurred while creating the invoice." }
            };
        }
    }

    public async Task<APIResponse<InvoiceResponseDTO>> UpdateInvoiceAsync(int id, InvoiceRequestDTO invoiceRequest)
    {
        var existingInvoice = await _invoiceRepository.GetByIdAsync(id);
        if (existingInvoice == null)
        {
            return new APIResponse<InvoiceResponseDTO>
            {
                Success = false,
                Title = "Invoice not found",
                Errors = new List<string> { $"No invoice found with ID: {id}" }
            };
        }

        using var transaction = await _invoiceRepository.BeginTransactionAsync();
        try
        {
            _mapper.Map(invoiceRequest, existingInvoice);
            await _invoiceRepository.UpdateAsync(existingInvoice);

            await _invoiceItemRepository.DeleteByInvoiceIdAsync(id);
            foreach (var item in invoiceRequest.InvoiceItems)
            {
                var invoiceItem = _mapper.Map<InvoiceItem>(item);
                invoiceItem.InvoiceId = id;
                await _invoiceItemRepository.AddAsync(invoiceItem);
            }

            await transaction.CommitAsync();

            var response = _mapper.Map<InvoiceResponseDTO>(existingInvoice);
            return new APIResponse<InvoiceResponseDTO>
            {
                Success = true,
                Payload = response,
                Title = "Invoice updated successfully"
            };
        }
        catch
        {
            await transaction.RollbackAsync();
            return new APIResponse<InvoiceResponseDTO>
            {
                Success = false,
                Title = "Invoice update failed",
                Errors = new List<string> { "An error occurred while updating the invoice." }
            };
        }
    }

    public async Task<APIResponse<bool>> DeleteInvoiceAsync(int id)
    {
        var existingInvoice = await _invoiceRepository.GetByIdAsync(id);
        if (existingInvoice == null)
        {
            return new APIResponse<bool>
            {
                Success = false,
                Title = "Invoice not found",
                Errors = new List<string> { $"No invoice found with ID: {id}" }
            };
        }

        await _invoiceItemRepository.DeleteByInvoiceIdAsync(id);
        await _invoiceRepository.DeleteAsync(id);

        return new APIResponse<bool>
        {
            Success = true,
            Payload = true,
            Title = "Invoice deleted successfully"
        };
    }
}
