# Music X Player 3.0.1 - ветка xf48_template 
![](/Images/logo.png)

## О проекте 
Music X - это мой форк музыкального плеера для в основном русскоговорящей социальной сети ВКонтакте, причем мультиплатформенный (для девайсов 
на операционных системах Windows и Android). 

Автором первоначального проекта является разработчик с ником Fooxboy. Fooxboy перевёл сей проект в режим read-only (по сути архив), но со своей командой пилит практически с нуля новый плеер: https://github.com/Fooxboy/MusicX-WPF

Его готовую beta-версию можно качнуть (или обсудить) в Telegram-канале https://t.me/MusicXPlayer

Моя цель в ветке xf48_template создать базу (шаблон) для такой переработки Music X под Xamarin Forms 4.8, чтобы результат, когда скомпилирую его под ARM, оказался совместимым со старшими сборками Windows 10 Mobile.


## Зачем мне это?
Я давний фанат ретро-системы Windows 10 Mobile. В качестве хобби, чисто по фану, иногда рождаю "прототипы" (читай - черновички) всяких там программочек- "полезняшек" (или наоборот, бесполезняшек) для этой отмененной Майками мобильной системы. Не так давно узнал я [тайну](https://gist.github.com/WamWooWam/e72e5137606f7c59ed657db6587cd5e8), что, оказывается, Windows 10 Mobile, начиная со сборки 15063 то умеет частично вращать uwp приложения, собранные с применением фишек SDK 16299 и .NET Standard 2! И вот родилась у меня мысль: а вдруг Music X Player я таким образом смогу адаптировать к работе на Windows 10 Mobile? =)

## Мои два цента
- При создании шаблона нового солюшна задействовал Xamarin Forms 4.8.0.1821
- Для проекта UWP мин. версия понижена до 16299 
- XAML практически пуст для проведения чистого эксперимента
- В .csproj и manifest внесены хакерские правки для попытки обеспечения совместимости с W10M! В солюшне Xamarin Forms, содержащем проекты .NET Standard 2, пробую это провернуть впервые. :) 

## Скриншот(ы)
![](/Images/screenshot01.png)

## Статус эксперимента
- Начало
- Что-то на винфоне Lumia 950 ничего под Windows 10 Mobile со сборкой 15254 не завелось. 

## .. 
Как есть. Чисто исследовательская тема. Сделай сам.

## .
mediaexplorer 

10 декабря 2024  

![](/Images/welcome.png)
