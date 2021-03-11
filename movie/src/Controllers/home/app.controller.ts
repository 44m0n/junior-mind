import { Controller, Get } from '@nestjs/common';
import { AppService } from 'src/models/app.service';

@Controller()
export class AppController {
  constructor(private readonly appService: AppService) {}

  @Get()
  root(): string {
    return this.appService.root();
  }
}
