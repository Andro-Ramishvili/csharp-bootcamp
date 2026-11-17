/*
მნიშვნელობები კოდში ჩაწერე. Input-ს ჯერ არ ვკითხულობთ, ეს ხვალინდელი თემაა:

ბალანსი: 1250.50
გადასარიცხი თანხა: 300
საკომისიო: გადარიცხვის 1.5%

Acceptance criteria:

ყველა თანხა decimal-შია, საკომისიოს პროცენტი const-ია.
იბეჭდება გადარიცხვა, საკომისიო, ჯამური ჩამოჭრა და ახალი ბალანსი, interpolation-ით ($"...").
bool canTransfer გამოითვლება ერთი გამოსახულებით: თანხა დადებითია და ბალანსი ყოფნის თანხასა და საკომისიოზე ერთად. 
ჯერ if-ის გარეშე, უბრალოდ დაბეჭდე.

Edge case-ები, რომლებიც ხელით შეამოწმე, მნიშვნელობების შეცვლით: თანხა 0; უარყოფითი თანხა; თანხა, 
რომელიც საკომისიოსთან ერთად ბალანსს ზუსტად უდრის; თანხა, რომელიც ბალანსზე 1 თეთრით მეტია.


*/

decimal balance = 1250m;
decimal transferAmount = -100m;
const decimal commissionRate = 0.015m;

decimal commission = transferAmount * commissionRate;
decimal totalDeduction = transferAmount + commission;
bool canTransfer = transferAmount > 0 && balance >= totalDeduction;

Console.WriteLine(canTransfer ? $"Transfer: {transferAmount:C} is successful. " +
 $"Commission: {commission:C}. " +
 $"Total deduction: {totalDeduction:C}. " +
 $"New balance: {(balance - (totalDeduction)):C}." 
 : $"Transfer: {transferAmount:C} failed. Insufficient funds or invalid amount.");

