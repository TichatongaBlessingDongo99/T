public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("AccountNumber,Balance")] Account account)
    {
        if (ModelState.IsValid)
        {
            _context.Add(account);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(account);
    }
}