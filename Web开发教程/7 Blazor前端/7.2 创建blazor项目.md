# 创建Blazor项目

FluentUI

## 使用TailwindCSS

安装

`npx tailwindcss init`

配置 tailwind.config.js

```javascript
module.exports = {
  content: ['./**/*.{razor,html}'],
  theme: {
    extend: {},
  },
  plugins: [],
}
```

创建一个开发时使用的app.css，并引入基础组件

```css
@tailwind base;
@tailwind components;
@tailwind utilities;
```

开启监测模式，并设置输出路径

`npx tailwindcss -i ./wwwroot/css/input.css -o ./wwwroot/css/output.css --watch`

## 使用FluentUI

安装

`Microsoft.FluentUI.AspNetCore.Components`

`Microsoft.FluentUI.AspNetCore.Components.Icons`
