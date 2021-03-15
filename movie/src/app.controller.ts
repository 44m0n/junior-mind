import { Controller, Get, Redirect, Render, Res } from '@nestjs/common';
import { AppService } from './app.service';

@Controller()
export class AppController {
  constructor(private readonly appService: AppService) {}

    @Get()
    @Render('main')
    root() {

        return { text: this.appService.roots() };

    }
}