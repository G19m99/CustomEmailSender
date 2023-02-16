namespace RazorHtmlEmails.RazorClassLib.Views.Emails.InvoiceEmail;

public record CreateInvoiceEmailViewModel(string baseUrl, int order_id, int plug_amt, int tire_amt, decimal amt_due, DateTime date);
