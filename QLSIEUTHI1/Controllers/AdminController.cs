﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
using QLSIEUTHI1.Data;
using QLSIEUTHI1.Models;
using Microsoft.EntityFrameworkCore;

public class AdminController : Controller
{
    private readonly QLSIEUTHI1Context _context;

    public AdminController(QLSIEUTHI1Context context)
    {
        _context = context;
    }

    // Trang chủ của Admin
    public IActionResult Index()
    {
        var products = _context.Product.ToList();
        return View(products);
    }

    // Hiển thị trang thêm sản phẩm mới
    public IActionResult Create()
    {
        return View();
    }

    // Xử lý yêu cầu POST để thêm sản phẩm mới
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description,ImageUrl,Price,Quantity,CategoryId")] Product product)
    {
        if (ModelState.IsValid)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // Hiển thị trang chỉnh sửa sản phẩm
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Product.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    // Xử lý yêu cầu POST để cập nhật sản phẩm
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImageUrl,Price,Quantity,CategoryId")] Product product)
    {
        if (id != product.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // Các phương thức khác cần thiết cho Admin
    // ...

    // Đăng xuất
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    private bool ProductExists(int id)
    {
        return _context.Product.Any(e => e.Id == id);
    }
}
