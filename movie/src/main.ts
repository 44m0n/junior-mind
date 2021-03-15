import { NestFactory } from '@nestjs/core';
import { NestExpressApplication } from '@nestjs/platform-express';
import { join } from 'path';
import { AppModule } from './app.module';
import * as hbs from 'hbs';

async function bootstrap() {
    const app = await NestFactory.create<NestExpressApplication>(
        AppModule,
    );

    hbs.registerHelper("release", function (fullDate) {
        var humanDate = new Date(fullDate).toDateString();
        return humanDate;
    })

    app.useStaticAssets(join(__dirname, '..', 'src/public'));
    app.setBaseViewsDir(join(__dirname, '..', 'src/views'));
   
    app.setViewEngine('hbs');
    await app.listen(3000);

}
bootstrap();