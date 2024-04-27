# Microsoft.Identity usage sample
#
### Maqsad: `Microsoft.Identity orqali Swaggerga quluf iconini chiqarmasdan va uyerga tokenni tashlamasdan Controllerlar methodlarini User Rolesiga qarab boshqarish imkoniyatini beradi` 
## Mavzular:
### UserManager----\
### RoleManager-----| -- Classlarini ishlatib ko'rish
### SignInManager--/
#
### AspNetUserTokenga tablesiga token yozish
### Cookiesga malumot append qilish
### Cookiedagi malumotni expire datesini ozgartirish 2 xil usul
#
## Steplar:
### 1: Models->AppUser
### 2: ApplicationIdentityDbContext
### 3: Programm -> Builder.Services.AddDbContext
### 4: Get, Create functions in Controller
### 5: Programm.cs->Nastroyka
### 6: Controller-> UserController
### ----------------CookieController
### 7: Controller-> Authorizelarni joylashtirish