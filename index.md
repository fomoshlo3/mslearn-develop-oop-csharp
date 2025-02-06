---
title: Lab files for "Learn To Program" training 
permalink: index.html
layout: home
---

# Exercises - develop object-oriented code

The following exercises are designed to support the modules on Microsoft Learn.


{% assign labs = site.pages | where_exp:"page", "page.url contains '/Instructions/Labs'" %}

{% for activity in labs  %} 
  - [{{ activity.lab.title }}]({{ site.github.url }}{{ activity.url }})
{% endfor %}
