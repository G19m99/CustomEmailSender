namespace RazorHtmlEmails.RazorClassLib.Views.Emails.InvoiceEmail;

public record CreateInvoiceEmailViewModel(string baseUrl, int order_id, List<item> items, decimal total, DateTime date);
