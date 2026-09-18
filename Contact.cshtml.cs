using ContactApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
namespace ContactApp.Pages 
{ public class ContactModel : PageModel 

{
	[BindProperty]
	public Contact Contact { get; set; } 
	public void OnGet() 
	{
	}
	public IActionResult OnPost() 
	{ if (!ModelState.IsValid)
	{
	return Page(); 
	
	} string dataFolder = Path.Combine(Directory.GetCurrentDirectory(), "data");
	
	Directory.CreateDirectory(dataFolder); 
	
	string filePath = Path.Combine(dataFolder, "contacts.json"); 
	
	List<Contact> contacts = new List<Contact>();
	
	
	if (System.IO.File.Exists(filePath)) 
	
	{
		
	string existingData = System.IO.File.ReadAllText(filePath); 
	
	if (!string.IsNullOrWhiteSpace(existingData)) 
	
	{
	
	contacts = JsonSerializer.Deserialize<List<Contact>>(existingData) ?? new List<Contact>();
		} 
	} 
	
	contacts.Add(Contact); 
	
	string json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions
	
	{
		WriteIndented = true
		
		}
		
		);
		
		System.IO.File.WriteAllText(filePath, json);
		
		return RedirectToPage("/ThankYou");
		
		}
		
			}	
				}