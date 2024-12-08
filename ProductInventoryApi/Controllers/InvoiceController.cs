using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllInvoices()
    {
        var response = await _invoiceService.GetAllInvoicesAsync();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInvoiceById(int id)
    {
        var response = await _invoiceService.GetInvoiceByIdAsync(id);
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateInvoice([FromBody] InvoiceRequestDTO invoiceRequest)
    {
        var response = await _invoiceService.CreateInvoiceAsync(invoiceRequest);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateInvoice(int id, [FromBody] InvoiceRequestDTO invoiceRequest)
    {
        var response = await _invoiceService.UpdateInvoiceAsync(id, invoiceRequest);
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInvoice(int id)
    {
        var response = await _invoiceService.DeleteInvoiceAsync(id);
        return response.Success ? Ok(response) : NotFound(response);
    }
}
