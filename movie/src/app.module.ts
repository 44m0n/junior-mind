import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { HelloworldModule } from './helloworld/helloworld.module';
import { MovieController } from './movie/movie.controller';


@Module({
  imports: [HelloworldModule],
  controllers: [AppController, MovieController],
  providers: [AppService]
})
export class AppModule {}
