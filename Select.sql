Select * from 成績單

Select 姓名 As 名字, English as 外文, 中文 from 成績單

select 姓名, 中文 + 數學 + English as 期中考總分 From 成績單

Select 姓名, 數學 From 成績單 Where 中文 > 90

select * from 成績單 Where 姓名 Like '林 %' --# 查不到 ??

select * from 成績單 Where 姓名 Like '_小美' --# 一樣查不到 ??

select * from 成績單 Where 姓名 Like '[a-f]ean' --# 一樣查不到 ??

select * from 成績單 Where SUBSTRING(姓名, 1, 1)='林' --# 一樣查不到 ??

select * from 成績單 where 數學 is Null And 中文 is not null --# 一樣查不到 ??

select * From 成績單 where 中文 in(80,85,88) -- Oh yeah!!
