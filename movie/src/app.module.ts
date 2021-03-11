import { Module } from '@nestjs/common';
import { AppController } from './controllers/home/app.controller';
import { AppService } from './models/app.service';
import { HelloWorldController } from './Controllers/hello-world/hello-world.controller';

@Module({
  imports: [],
  controllers: [AppController, HelloWorldController],
  providers: [AppService],
})
export class AppModule {}
