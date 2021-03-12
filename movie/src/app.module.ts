import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { HelloworldModule } from './helloworld/helloworld.module';
import { MovieController } from './movie/movie.controller';
import { TypeOrmModule } from '@nestjs/typeorm';
import { Connection } from 'typeorm';


@Module({
    imports: [HelloworldModule, TypeOrmModule.forRoot()],
    controllers: [AppController, MovieController],
    providers: [AppService]
})
export class AppModule {
    constructor(private connection: Connection) { }
}
