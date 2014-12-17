select Price, City, FileName
from Houses
Inner Join Pictures
ON Houses.HouseID = Pictures.HouseID
Where Houses.Price > 3000;
